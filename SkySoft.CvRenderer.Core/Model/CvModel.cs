using System.Text.Json.Serialization;

namespace SkySoft.CvRenderer.Core.Model
{
    public class CvModel
    {
        [JsonPropertyName("basics")]
        public Basics Basics { get; set; }

        [JsonPropertyName("work")]
        public List<Work> Work { get; set; }

        [JsonPropertyName("volunteer")]
        public List<Volunteer> Volunteer { get; set; }

        [JsonPropertyName("education")]
        public List<Education> Education { get; set; }

        [JsonPropertyName("awards")]
        public List<Award> Awards { get; set; }

        [JsonPropertyName("certificates")]
        public List<Certificate> Certificates { get; set; }

        [JsonPropertyName("publications")]
        public List<Publication> Publications { get; set; }

        [JsonPropertyName("skills")]
        public List<Skill> Skills { get; set; }

        [JsonPropertyName("languages")]
        public List<Language> Languages { get; set; }

        [JsonPropertyName("interests")]
        public List<Interest> Interests { get; set; }

        [JsonPropertyName("references")]
        public List<Reference> References { get; set; }

        [JsonPropertyName("projects")]
        public List<Project> Projects { get; set; }
    }


    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Award
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("awarder")]
        public string Awarder { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }

    public class Basics
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("profiles")]
        public List<Profile> Profiles { get; set; }
    }

    public class Certificate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Education
    {
        [JsonPropertyName("institution")]
        public string Institution { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("studyType")]
        public string StudyType { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("score")]
        public string Score { get; set; }

        [JsonPropertyName("courses")]
        public List<string> Courses { get; set; }
    }

    public class Interest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }
    }

    public class Language
    {
        [JsonPropertyName("language")]
        public string Name { get; set; }

        [JsonPropertyName("fluency")]
        public string Fluency { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }
    }

    public class Profile
    {
        [JsonPropertyName("network")]
        public string Network { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Project
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("highlights")]
        public List<string> Highlights { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Publication
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }

    public class Reference
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("reference")]
        public string Text { get; set; }
    }

    public class Skill
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("level")]
        public string Level { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }
    }

    public class Volunteer
    {
        [JsonPropertyName("organization")]
        public string Organization { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("highlights")]
        public List<string> Highlights { get; set; }
    }

    public class Work
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("highlights")]
        public List<string> Highlights { get; set; }
    }


}
