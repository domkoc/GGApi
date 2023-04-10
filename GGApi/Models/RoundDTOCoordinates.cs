using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class RoundDTOCoordinates : IEquatable<RoundDTOCoordinates>
    { 
        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>

        [DataMember(Name="longitude")]
        public decimal? Longitude { get; set; }

        /// <summary>
        /// Gets or Sets Lattitude
        /// </summary>

        [DataMember(Name="lattitude")]
        public decimal? Lattitude { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RoundDTOCoordinates {\n");
            sb.Append("  Longitude: ").Append(Longitude).Append("\n");
            sb.Append("  Lattitude: ").Append(Lattitude).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RoundDTOCoordinates)obj);
        }

        /// <summary>
        /// Returns true if RoundDTOCoordinates instances are equal
        /// </summary>
        /// <param name="other">Instance of RoundDTOCoordinates to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoundDTOCoordinates other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Longitude == other.Longitude ||
                    Longitude != null &&
                    Longitude.Equals(other.Longitude)
                ) && 
                (
                    Lattitude == other.Lattitude ||
                    Lattitude != null &&
                    Lattitude.Equals(other.Lattitude)
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
                    if (Longitude != null)
                    hashCode = hashCode * 59 + Longitude.GetHashCode();
                    if (Lattitude != null)
                    hashCode = hashCode * 59 + Lattitude.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(RoundDTOCoordinates left, RoundDTOCoordinates right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoundDTOCoordinates left, RoundDTOCoordinates right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
