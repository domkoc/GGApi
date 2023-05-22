using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class RoundDTO : IEquatable<RoundDTO>
    {
        /// <summary>
        /// Gets or Sets Tasks
        /// </summary>

        [DataMember(Name = "tasks")]
        public List<RoundDTOTasks> Tasks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RoundDTO {\n");
            sb.Append("  Tasks: ").Append(Tasks).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RoundDTO)obj);
        }

        /// <summary>
        /// Returns true if RoundDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of RoundDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RoundDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return

                    Tasks == other.Tasks ||
                    Tasks != null &&
                    Tasks.SequenceEqual(other.Tasks)
                ;
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
                if (Tasks != null)
                    hashCode = hashCode * 59 + Tasks.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(RoundDTO left, RoundDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RoundDTO left, RoundDTO right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
