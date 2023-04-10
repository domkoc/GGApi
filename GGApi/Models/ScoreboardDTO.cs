using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ScoreboardDTO : IEquatable<ScoreboardDTO>
    { 
        /// <summary>
        /// Gets or Sets Players
        /// </summary>

        [DataMember(Name="players")]
        public List<ScoreboardDTOPlayers> Players { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ScoreboardDTO {\n");
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
            return obj.GetType() == GetType() && Equals((ScoreboardDTO)obj);
        }

        /// <summary>
        /// Returns true if ScoreboardDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of ScoreboardDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ScoreboardDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
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
                    if (Players != null)
                    hashCode = hashCode * 59 + Players.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ScoreboardDTO left, ScoreboardDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScoreboardDTO left, ScoreboardDTO right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
