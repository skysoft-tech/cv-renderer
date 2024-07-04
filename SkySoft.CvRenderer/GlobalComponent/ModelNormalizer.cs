using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class ModelNormalizer
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;

        public ModelNormalizer(ILogger logger, CvModel cvModel) 
        { 
            _logger = logger;
            _cvModel = cvModel;
        }

        public void Normalize() 
        {
            _logger.LogDebug("Start CvModel validation...");

            ValidateBasics();
            ValidateSection(_cvModel.Work!, work => Valid(work.Highlights!));
            ValidateSection(_cvModel.Volunteer!, volunteer => Valid(volunteer.Highlights!));
            ValidateSection(_cvModel.Education!, education => Valid(education.Courses!));
            ValidateSection(_cvModel.Awards!);
            ValidateSection(_cvModel.Certificates!);
            ValidateSection(_cvModel.Publications!);
            ValidateSection(_cvModel.Skills!, skill => Valid(skill.Keywords!));
            ValidateSection(_cvModel.Languages!);
            ValidateSection(_cvModel.Interests!, interests => Valid(interests.Keywords!));
            ValidateSection(_cvModel.References!);
            ValidateSection(_cvModel.Projects!, project =>
            {
                Valid(project.Keywords!);
                Valid(project.Highlights!);
            });
        }

        private void Valid<T>(List<T> value)
        {
            if (value is null)
            {
                return;
            }

            value.RemoveAll(item => item is null);
        }

        private void ValidateSection<T>(List<T> section, Action<T>? additionalValidation = null)
        {
            if (section is null)
            {
                return;
            }

            Valid(section);

            if (additionalValidation is not null)
            {
                foreach (var item in section)
                {
                    additionalValidation(item);
                }
            }
        }
        private void ValidateBasics()
        {
            Valid(_cvModel.Basics!.Profiles!);
        }
    }
}
