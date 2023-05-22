using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class GameStateDTOPlayers : IEquatable<GameStateDTOPlayers>
    {
        /// <summary>
        /// Gets or Sets Username
        /// </summary>

        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Score
        /// </summary>

        [DataMember(Name = "score")]
        public int? Score { get; set; }

        /// <summary>
        /// Gets or Sets IsPlaying
        /// </summary>

        [DataMember(Name = "isPlaying")]
        public bool? IsPlaying { get; set; }

        /// <summary>
        /// Gets or Sets HasSubmittedAnswer
        /// </summary>

        [DataMember(Name = "hasSubmittedAnswer")]
        public bool? HasSubmittedAnswer { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GameStateDTOPlayers {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Score: ").Append(Score).Append("\n");
            sb.Append("  IsPlaying: ").Append(IsPlaying).Append("\n");
            sb.Append("  HasSubmittedAnswer: ").Append(HasSubmittedAnswer).Append("\n");
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
            return obj.GetType() == GetType() && Equals((GameStateDTOPlayers)obj);
        }

        /// <summary>
        /// Returns true if GameStateDTOPlayers instances are equal
        /// </summary>
        /// <param name="other">Instance of GameStateDTOPlayers to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GameStateDTOPlayers other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Username == other.Username ||
                    Username != null &&
                    Username.Equals(other.Username)
                ) &&
                (
                    Score == other.Score ||
                    Score != null &&
                    Score.Equals(other.Score)
                ) &&
                (
                    IsPlaying == other.IsPlaying ||
                    IsPlaying != null &&
                    IsPlaying.Equals(other.IsPlaying)
                ) &&
                (
                    HasSubmittedAnswer == other.HasSubmittedAnswer ||
                    HasSubmittedAnswer != null &&
                    HasSubmittedAnswer.Equals(other.HasSubmittedAnswer)
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
                if (Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                if (Score != null)
                    hashCode = hashCode * 59 + Score.GetHashCode();
                if (IsPlaying != null)
                    hashCode = hashCode * 59 + IsPlaying.GetHashCode();
                if (HasSubmittedAnswer != null)
                    hashCode = hashCode * 59 + HasSubmittedAnswer.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(GameStateDTOPlayers left, GameStateDTOPlayers right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameStateDTOPlayers left, GameStateDTOPlayers right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
