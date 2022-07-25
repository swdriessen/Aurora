using System.Text;

namespace Aurora.Engine.Data
{
    public class ElementDescriptionBuilder
    {
        private string? headerContent;
        private string? informationContent;
        private string? rulesContent;
        private string? footerContent;

        private ElementDescriptionBuilder()
        {
        }

        public static ElementDescriptionBuilder CreateBuilder()
        {
            return new ElementDescriptionBuilder();
        }

        public ElementDescriptionBuilder Header(string content)
        {
            headerContent = content;
            return this;
        }

        public ElementDescriptionBuilder Information(string content)
        {
            informationContent = content;
            return this;
        }

        public ElementDescriptionBuilder Rules(string content)
        {
            rulesContent = content;
            return this;
        }

        public ElementDescriptionBuilder Footer(string content)
        {
            footerContent = content;
            return this;
        }

        public string Build()
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(headerContent))
            {
                builder.AppendLine(headerContent);
            }

            if (!string.IsNullOrWhiteSpace(informationContent))
            {
                builder.AppendLine(informationContent);
            }

            if (!string.IsNullOrWhiteSpace(rulesContent))
            {
                builder.AppendLine(rulesContent);
            }

            if (!string.IsNullOrWhiteSpace(footerContent))
            {
                builder.AppendLine(footerContent);
            }

            return builder.ToString();
        }
    }
}
