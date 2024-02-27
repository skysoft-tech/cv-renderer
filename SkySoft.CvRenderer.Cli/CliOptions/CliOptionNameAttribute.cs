using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public class CliOptionNameAttribute : Attribute
    {
        public string[] Aliases { get; set; }

        public CliOptionNameAttribute(params string[] aliases)
        {
            Aliases = aliases;
        }
    }
}
