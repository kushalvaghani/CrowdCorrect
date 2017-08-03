using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowdCorrect.Models
{
    public class CrowdTask
    {
        public CrowdTask()
        {
            KeywordData = new KeywordData();
            TagQuestion = new TagQuestion();
            CorrectionQuestion = new CorrectionQuestion();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; } // the question
        public KeywordData KeywordData { get; set; }
        public TagQuestion TagQuestion { get; set; }

        public CorrectionQuestion CorrectionQuestion { get; set; }
    }

    public class TagQuestion
    {
        public TagQuestion()
        {
            Tags = new List<TagInfo>();
        }

        public List<TagInfo> Tags { get; set; }
    }

    public class CorrectionQuestion
    {
        public CorrectionQuestion()
        {
            Suggestions = new List<Suggestion>();
            Tag = new TagInfo();
        }
        public TagInfo Tag { get; set; }

        public List<Suggestion> Suggestions { get; set; }
    }

    public class TagInfo
    {
        public int TagId { get; set; }
        public int TagCount { get; set; }

        public string TagName { get; set; }
        public bool IsMarked { get; set; }
    }

    public class Suggestion
    {
        public string Text { get; set; }

        public string Source { get; set; }
        public bool IsMarked { get; set; }
    }

    public class KeywordData
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}