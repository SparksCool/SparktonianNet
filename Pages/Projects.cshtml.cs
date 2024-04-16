using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace SparktonianNet.Pages
{
    public class ProjectsModel : PageModel
    {
        public void OnGet()
        {

        }

        // Define a Project class to represent a project
        class Project
        {
            // Define the properties of a Project
            // Name of the project
            public required string Name { get; set; }
            // Description of the project
            public required string Description { get; set; }
            // URL to the GitHub repository
            public required string GitHubUrl { get; set; }
            // URL to the demo of the project
            public string? DemoUrl { get; set; }
            // URL to the image of the project
            public required string ImageUrl { get; set; }
            // Tags associated with the project
            public required string[] Tags { get; set; }
        }
        
        // Function to get the HTML of all projects in the Projects folder
        public string GetProjectsHTML()
        {

            // HTML Template string for a project entry
            string HTMLTemplate =
                "<div class=\"projectEntry\" href=\"{3}\">" +
                "<h3 class=\"projectTitle\">{0}</h3>" +
                "<p class=\"projectDesc\">{1}</p>" +
                "<ul class=\"projectTags\">{2}</ul>" +
                "<a class=\"projectSource text-dark text-decoration-none\" href=\"{3}\">Source Code</a>" +
                // "<a class=\"projectDemo text-dark text-decoration-none\" href=\"{3}\">Live Demo</a>" +
                "</div> <br>";
            // HTML Template for a tag
            string HTMLTagTemplate = "<li class=\"projectTag\">{0}</li>";

            // Output formatted HTML listing all projects
            string HTMLOutput = "";
            // Get a list of all JSON files in the Projects folder
            var files = System.IO.Directory.GetFiles("Resources/Projects/", "*.json");

            // Loop through each JSON file in the Projects folder
            foreach (var file in files)
            {
                // Read the contents of the JSON file into a Project object
                Project? project = JsonSerializer.Deserialize<Project>(System.IO.File.ReadAllText(file));

                // List of tags for a project
                List<string> tags = new List<string>();

                // If the project is null, output "NULL!" and continue to the next project
                if (project == null)
                {
                    HTMLOutput += "NULL!";
                    continue;
                }

                // Assemble the HTML output for the project
                foreach (var tag in project.Tags)
                {
                    tags.Add(string.Format(HTMLTagTemplate, tag));
                }

                // Add the project to the HTML output
                HTMLOutput += string.Format(HTMLTemplate, project.Name, project.Description, string.Join("", tags), project.GitHubUrl);

            }

            // Return the formatted HTML output of all projects in the Projects folder
            return HTMLOutput;
        }
    }
}
