using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Infrastructure.Dto
{
    [SwaggerSchema("YourModelDropdownOptions")]
    public enum DropdownOptions
    {
        Option1,
        Option2,
        Option3
    }
    public class DropDownListDto
    { /// <summary>
      /// Gets or sets the selected value from the dropdown list.
      /// </summary>
      /// <remarks>
      /// Possible values: Option1, Option2, Option3
      /// </remarks>
       [SwaggerSchema("YourModelDropdownOptions")]
        public string SelectedValue { get; set; }
    }
}
