/*
 * GG App
 *
 * This is the OpenAPI 3.0 Documentation of the GG App.  Useful links: - [The OpenAPI repository](https://github.com/domkoc/GGApp-OpenAPI)
 *
 * OpenAPI spec version: 0.1.5
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Text;
using System.Runtime.Serialization;

namespace GGApi.Models.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AnswersDTO : IEquatable<AnswersDTO>
    {
        /// <summary>
        /// Gets or Sets Username
        /// </summary>

        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Answers
        /// </summary>

        [DataMember(Name = "answers")]
        public List<AnswersDTOAnswers> Answers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AnswersDTO {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Answers: ").Append(Answers).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AnswersDTO)obj);
        }

        /// <summary>
        /// Returns true if AnswersDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of AnswersDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AnswersDTO other)
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
                    Answers == other.Answers ||
                    Answers != null &&
                    Answers.SequenceEqual(other.Answers)
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
                if (Answers != null)
                    hashCode = hashCode * 59 + Answers.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(AnswersDTO left, AnswersDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnswersDTO left, AnswersDTO right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
