using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class GameStateDTO : IEquatable<GameStateDTO>
    {
        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataContract]
        public enum StateEnum
        {
            /// <summary>
            /// Enum WaitingForPlayersEnum for waitingForPlayers
            /// </summary>
            [EnumMember(Value = "waitingForPlayers")]
            WaitingForPlayersEnum = 0,
            /// <summary>
            /// Enum StartEnum for start
            /// </summary>
            [EnumMember(Value = "start")]
            StartEnum = 1
        }

        /// <summary>
        /// Gets or Sets State
        /// </summary>

        [DataMember(Name = "state")]
        public StateEnum? State { get; set; }

        /// <summary>
        /// Gets or Sets Players
        /// </summary>

        [DataMember(Name = "players")]
        public List<GameStateDTOPlayers> Players { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GameStateDTO {\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Players: ").Append(Players).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((GameStateDTO)obj);
        }

        /// <summary>
        /// Returns true if GameStateDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of GameStateDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GameStateDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    State == other.State ||
                    State != null &&
                    State.Equals(other.State)
                ) &&
                (
                    Players == other.Players ||
                    Players != null &&
                    Players.SequenceEqual(other.Players)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (State != null)
                    hashCode = hashCode * 59 + State.GetHashCode();
                if (Players != null)
                    hashCode = hashCode * 59 + Players.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(GameStateDTO left, GameStateDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameStateDTO left, GameStateDTO right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
