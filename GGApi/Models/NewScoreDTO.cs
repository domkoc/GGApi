using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class NewScoreDTO : IEquatable<NewScoreDTO>
    { 
        /// <summary>
        /// Gets or Sets LobbyId
        /// </summary>

        [DataMember(Name="lobbyId")]
        public string LobbyId { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>

        [DataMember(Name="username")]
        public string Username { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NewScoreDTO {\n");
            sb.Append("  LobbyId: ").Append(LobbyId).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
            return obj.GetType() == GetType() && Equals((NewScoreDTO)obj);
        }

        /// <summary>
        /// Returns true if NewScoreDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of NewScoreDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NewScoreDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    LobbyId == other.LobbyId ||
                    LobbyId != null &&
                    LobbyId.Equals(other.LobbyId)
                ) && 
                (
                    Username == other.Username ||
                    Username != null &&
                    Username.Equals(other.Username)
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
                    if (LobbyId != null)
                    hashCode = hashCode * 59 + LobbyId.GetHashCode();
                    if (Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(NewScoreDTO left, NewScoreDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NewScoreDTO left, NewScoreDTO right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
