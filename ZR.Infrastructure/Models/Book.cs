/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	20/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/
 
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace ZR.Infrastructure.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Book : IEquatable<Book>
    {

        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name = "id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id { get; set; }

        
        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [Required(ErrorMessage = "Missing Book Title !")]

        [DataMember(Name = "title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets Author
        /// </summary>
        [Required(ErrorMessage = "Missing Book Author Name !")]

        [DataMember(Name = "author")]
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [Required(ErrorMessage = "Missing Book Price !")]

        [DataMember(Name = "price")]
        public decimal? Price { get; set; } = decimal.Zero;





        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder? sb = new StringBuilder();
            sb.Append("class Book {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Author: ").Append(Author).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Book)obj);
        }

        /// <summary>
        /// Returns true if Book instances are equal
        /// </summary>
        /// <param name="other">Instance of Book to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) &&
                (
                    Author == other.Author ||
                    Author != null &&
                    Author.Equals(other.Author)
                ) &&
                (
                    Price == other.Price ||
                    Price != null &&
                    Price.Equals(other.Price)
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
                int hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                {
                    hashCode = hashCode * 59 + Id.GetHashCode();
                }

                if (Title != null)
                {
                    hashCode = hashCode * 59 + Title.GetHashCode();
                }

                if (Author != null)
                {
                    hashCode = hashCode * 59 + Author.GetHashCode();
                }

                if (Price != null)
                {
                    hashCode = hashCode * 59 + Price.GetHashCode();
                }

                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Book left, Book right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Book left, Book right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
