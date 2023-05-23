using GGApi.Models.DB;
using GGApi.Models.DTOs;
using GeoCoordinatePortable;

namespace GGApi.Services
{
    public class Lobby
    {
        public class Question
        {
            public String Title;
            public Decimal Longitude;
            public Decimal Latitude;
            public int Seconds = 20;

            public Question(String title, Decimal longitude, Decimal latitude)
            {
                Title = title;
                Longitude = longitude;
                Latitude = latitude;
                Seconds = 0;
            }

            public Question(Location location)
            {
                Title = location.Name;
                Longitude = location.Longitude;
                Latitude = location.Latitude;
            }
        }

        public class Player
        {
            public String Username;
            public int Score = 0;
            public bool IsPlaying = true;
            public bool HasSubmittedAnswer
            {
                get
                {
                    return Answers.Count > 0;
                }
            }
            public List<Question> Answers = new List<Question>();
        }

        public String Id;
        public List<Player> Players;
        public bool Started = false;
        public List<Question> Questions;

        public GameStateDTO AsGameStateDto
        {
            get
            {
                var dtoPlayers = new List<GameStateDTOPlayers>();
                foreach (var player in Players)
                {
                    dtoPlayers.Add(new GameStateDTOPlayers()
                    {
                        Username = player.Username,
                        Score = player.Score,
                        IsPlaying = player.IsPlaying,
                        HasSubmittedAnswer = player.HasSubmittedAnswer
                    });
                }
                return new GameStateDTO()
                {
                    Players = dtoPlayers,
                    State = Started ? GameStateDTO.StateEnum.StartEnum : GameStateDTO.StateEnum.WaitingForPlayersEnum
                };
            }
        }

        public RoundDTO AsRoundDto
        {
            get
            {
                var dtoTasks = new List<RoundDTOTasks>();
                foreach (var question in Questions)
                {
                    dtoTasks.Add(new RoundDTOTasks()
                    {
                        Title = question.Title,
                        Coordinates = new RoundDTOCoordinates()
                        {
                            Longitude = question.Longitude,
                            Lattitude = question.Latitude
                        },
                        Seconds = question.Seconds
                    });
                }
                return new RoundDTO()
                {
                    Tasks = dtoTasks
                };
            }
        }
    }
    public class GameService
    {
        private static List<Lobby> Lobbies = new List<Lobby>();

        private readonly LocationService _locationService;
        public GameService(LocationService locationService)
        {
            _locationService = locationService;
        }

        // Create a new game lobby
        public async void CreateGame(String username, String lobbyId)
        {
            Lobbies.Add(new Lobby() 
            { 
                Id = lobbyId, 
                Players = new List<Lobby.Player>() 
                { 
                    new Lobby.Player() 
                    { 
                        Username = username 
                    } 
                },
                Questions = LocationsToQuestions(await _locationService.GetRandomLocationAsync(5))
            });
        }

        // Join an existing game lobby
        public bool JoinGame(String username, String lobbyId)
        {
            var lobby = Lobbies.Find(x => x.Id == lobbyId);
            if (lobby == null)
            {
                return false;
            }
            lobby.Players.Add(new Lobby.Player() 
            { 
                Username = username 
            });
            return true;
        }

        // Start a game lobby
        public Lobby? StartGame(String lobbyId)
        {
            var lobby = Lobbies.Find(x => x.Id == lobbyId);
            if (lobby == null)
            {
                return null;
            }
            lobby.Started = true;
            return lobby;
        }

        // Get a game lobby
        public Lobby? GetGame(String lobbyId)
        {
            var lobby = Lobbies.Find(x => x.Id == lobbyId);
            if (lobby == null)
            {
                return null;
            }
            return lobby;
        }

        // Submit answer by username
        public bool SubmitAnswers(String lobbyId, String username, List<Lobby.Question> answers)
        {
            var lobby = Lobbies.Find(x => x.Id == lobbyId);
            if (lobby == null)
            {
                return false;
            }
            var player = lobby.Players.Find(x => x.Username == username);
            if (player == null)
            {
                return false;
            }
            player.Answers.AddRange(answers);
            CheckAnswers(lobby);
            return true;
        }

        private void CheckAnswers(Lobby lobby)
        {
            foreach (var player in lobby.Players)
            {
                if (!player.HasSubmittedAnswer) return;
            }
            ComputePoints(lobby);
        }

        private void ComputePoints(Lobby lobby)
        {
            foreach (var player in lobby.Players)
            {
                foreach (var answer in player.Answers)
                {
                    var question = lobby.Questions.Find(x => x.Title == answer.Title);
                    var answerCoord = new GeoCoordinate(Decimal.ToDouble(answer.Latitude), Decimal.ToDouble(answer.Longitude));
                    var questionCoord = new GeoCoordinate(Decimal.ToDouble(question.Latitude), Decimal.ToDouble(question.Longitude));

                    var distance = answerCoord.GetDistanceTo(questionCoord);
                    if (distance < 30 * 1000)
                    {
                        player.Score += 100;
                    }
                    else if (distance < 60 * 1000)
                    {
                        player.Score += 50;
                    }
                    else if (distance < 120 * 1000)
                    {
                        player.Score += 25;
                    }
                }
            }
            Eliminate(lobby);
        }

        private void Eliminate(Lobby lobby)
        {
            var players = lobby.Players;
            players.Sort((x, y) => x.Score.CompareTo(y.Score));
            players.Last().IsPlaying = false;
        }

        private static List<Lobby.Question> LocationsToQuestions(List<Location> locations)
        {
            var questions = new List<Lobby.Question>();
            foreach (var location in locations)
            {
                questions.Add(new Lobby.Question(location));
            }
            return questions;
        }
    }
}
