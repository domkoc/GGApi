using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ScoreboardDTOPlayers : IEquatable<ScoreboardDTOPlayers>
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScoreboardDTOPlayers {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Score: ").Append(Score).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ScoreboardDTOPlayers)obj);
        }

        /// <summary>
        /// Returns true if ScoreboardDTOPlayers instances are equal
        /// </summary>
        /// <param name="other">Instance of ScoreboardDTOPlayers to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScoreboardDTOPlayers other)
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
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ScoreboardDTOPlayers left, ScoreboardDTOPlayers right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScoreboardDTOPlayers left, ScoreboardDTOPlayers right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
