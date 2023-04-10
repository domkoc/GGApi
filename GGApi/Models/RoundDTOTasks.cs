using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class RoundDTOTasks : IEquatable<RoundDTOTasks>
    { 
        /// <summary>
        /// Gets or Sets Title
        /// </summary>

        [DataMember(Name="title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Coordinates
        /// </summary>

        [DataMember(Name="coordinates")]
        public RoundDTOCoordinates Coordinates { get; set; }

        /// <summary>
        /// Gets or Sets Seconds
        /// </summary>

        [DataMember(Name="seconds")]
        public decimal? Seconds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RoundDTOTasks {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Coordinates: ").Append(Coordinates).Append("\n");
            sb.Append("  Seconds: ").Append(Seconds).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RoundDTOTasks)obj);
        }

        /// <summary>
        /// Returns true if RoundDTOTasks instances are equal
        /// </summary>
        /// <param name="other">Instance of RoundDTOTasks to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoundDTOTasks other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    Coordinates == other.Coordinates ||
                    Coordinates != null &&
                    Coordinates.Equals(other.Coordinates)
                ) && 
                (
                    Seconds == other.Seconds ||
                    Seconds != null &&
                    Seconds.Equals(other.Seconds)
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
                    if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                    if (Coordinates != null)
                    hashCode = hashCode * 59 + Coordinates.GetHashCode();
                    if (Seconds != null)
                    hashCode = hashCode * 59 + Seconds.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(RoundDTOTasks left, RoundDTOTasks right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoundDTOTasks left, RoundDTOTasks right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
