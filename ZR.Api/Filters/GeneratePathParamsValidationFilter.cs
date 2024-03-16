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
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;

namespace ZR.Api.Filters
{
    /// <summary>
    /// Path Parameter Validation Rules Filter
    /// </summary>
    public class GeneratePathParamsValidationFilter : IOperationFilter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <param name="context">OperationFilterContext</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            IList<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription>? pars = context.ApiDescription.ParameterDescriptions;

            foreach (Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription? par in pars)
            {
                OpenApiParameter? swaggerParam = operation.Parameters.SingleOrDefault(p => p.Name == par.Name);

                IEnumerable<System.Reflection.CustomAttributeData>? attributes = ((ControllerParameterDescriptor)par.ParameterDescriptor).ParameterInfo.CustomAttributes;

                if (attributes != null && attributes.Count() > 0 && swaggerParam != null)
                {
                    // Required - [Required]
                    System.Reflection.CustomAttributeData? requiredAttr = attributes.FirstOrDefault(p => p.AttributeType == typeof(RequiredAttribute));
                    if (requiredAttr != null)
                    {
                        swaggerParam.Required = true;
                    }

                    // Regex Pattern [RegularExpression]
                    System.Reflection.CustomAttributeData? regexAttr = attributes.FirstOrDefault(p => p.AttributeType == typeof(RegularExpressionAttribute));
                    if (regexAttr != null)
                    {
                        string regex = (string)regexAttr.ConstructorArguments[0].Value;
                        if (swaggerParam is OpenApiParameter)
                        {
                            swaggerParam.Schema.Pattern = regex;
                        }
                    }

                    // String Length [StringLength]
                    int? minLenght = null, maxLength = null;
                    System.Reflection.CustomAttributeData? stringLengthAttr = attributes.FirstOrDefault(p => p.AttributeType == typeof(StringLengthAttribute));
                    if (stringLengthAttr != null)
                    {
                        if (stringLengthAttr.NamedArguments.Count == 1)
                        {
                            minLenght = (int)stringLengthAttr.NamedArguments.Single(p => p.MemberName == "MinimumLength").TypedValue.Value;
                        }
                        maxLength = (int)stringLengthAttr.ConstructorArguments[0].Value;
                    }

                    System.Reflection.CustomAttributeData? minLengthAttr = attributes.FirstOrDefault(p => p.AttributeType == typeof(MinLengthAttribute));
                    if (minLengthAttr != null)
                    {
                        minLenght = (int)minLengthAttr.ConstructorArguments[0].Value;
                    }

                    System.Reflection.CustomAttributeData? maxLengthAttr = attributes.FirstOrDefault(p => p.AttributeType == typeof(MaxLengthAttribute));
                    if (maxLengthAttr != null)
                    {
                        maxLength = (int)maxLengthAttr.ConstructorArguments[0].Value;
                    }

                    if (swaggerParam is OpenApiParameter)
                    {
                        swaggerParam.Schema.MinLength = minLenght;
                        swaggerParam.Schema.MaxLength = maxLength;
                    }

                    // Range [Range]
                    System.Reflection.CustomAttributeData? rangeAttr = attributes.FirstOrDefault(p => p.AttributeType == typeof(RangeAttribute));
                    if (rangeAttr != null)
                    {
                        int rangeMin = (int)rangeAttr.ConstructorArguments[0].Value;
                        int rangeMax = (int)rangeAttr.ConstructorArguments[1].Value;

                        if (swaggerParam is OpenApiParameter)
                        {
                            swaggerParam.Schema.Minimum = rangeMin;
                            swaggerParam.Schema.Maximum = rangeMax;
                        }
                    }
                }
            }
        }
    }
}
