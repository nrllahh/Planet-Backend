using Planet.Domain.SharedKernel;
using System.Text.RegularExpressions;

namespace Planet.Domain.Boards
{
    public record BoardLabelColor
    {
        public string Value { get; init; }

        private BoardLabelColor() { }

        private BoardLabelColor(string colorCode)
        {

            if (string.IsNullOrWhiteSpace(colorCode))
            {
                throw new DomainException("Color.NullOrWhiteSpace", "Renk boş olamaz!");
            }

            colorCode = colorCode.ToLower();

            if (!Regex.IsMatch(colorCode, @"#?[a-f0-9]{6}"))
            {
                throw new DomainException("Color.NotValid", "Renk kodu geçerli değil!");
            }

            Value = colorCode.StartsWith("#") ? colorCode : $"#{colorCode}";
        }

        public static BoardLabelColor Create(string colorCode)
        {
            return new BoardLabelColor(colorCode);
        }
    }
}
