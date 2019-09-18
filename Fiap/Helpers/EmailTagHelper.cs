using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Helpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Nome { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var email = $"{Nome}@fiap.com.br";

            output.Attributes.SetAttribute("href", "mailto:" + email);
            output.Content.SetContent(email);

            //base.Process(context, output);
        }
    }
}
