using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class OptionKeyNameAttribute : Attribute
    {
        public string Name { get; }

        public OptionKeyNameAttribute(string name)
        {
            Name = name;
        }
    }
}
