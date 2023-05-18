using MercuryProject.Domain.Enums;
using MercuryProject.Domain.Idea.ValueObjects;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Domain.Idea.Dto
{
    public class IdeaDto
    {
        public IdeaId Id { get; set; }
        public UserId OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IdeaStatus Status { get; set; }
        public decimal Goal { get; set; }
        public decimal Collected { get; set; }
        public string Category { get; set; }
        public IReadOnlyList<string> IdeaImageUrls { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
