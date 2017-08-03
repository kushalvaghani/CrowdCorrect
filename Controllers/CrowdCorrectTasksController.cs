using CrowdCorrect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CrowdCorrect.Controllers
{
    public class CrowdCorrectTasksController : ApiController
    {
        [HttpGet]
        public CrowdTask Get(bool nextSuggestion)
        {
            using (CrowdCorrectEntities db = new CrowdCorrectEntities())
            {
                int index = PickTweet(nextSuggestion);
                if (index == 0)
                    return new CrowdTask();
                Tweet tw = db.Tweets.FirstOrDefault(t => t.Id == index);
                //
                CrowdTask task = new CrowdTask()
                {
                    Id = tw.Id,
                    Text = tw.Text
                };
                //

                if (nextSuggestion)
                {
                    var keywords = tw.Keywords.Where(ke => ke.UserKeywordTags.Count() > 0);
                    int id = new Random().Next(keywords.Count());
                    var keyword = keywords.ElementAt(id);
                    int tagId = new Random().Next(keyword.UserKeywordTags.Count());
                    var tag = keyword.UserKeywordTags.ElementAt(tagId);
                    //
                    task.Description = "In the above tweet, the keyword \'" + keyword.Keyword1 + "\' is marked as being a " + tag.Tag.Name
                        + ". Which of the below suggestion is appropraite ?";
                    task.KeywordData.Id = keyword.Id;
                    task.KeywordData.Name = keyword.Keyword1;
                    //
                    task.CorrectionQuestion.Tag.TagId = tag.Tag.Id;
                    task.CorrectionQuestion.Tag.TagName = tag.Tag.Name;
                    task.CorrectionQuestion.Tag.IsMarked = true;
                    task.CorrectionQuestion.Tag.TagCount = 1;
                    foreach (string suggestion in GetSuggestions(task.KeywordData, tag))
                    {
                        task.CorrectionQuestion.Suggestions.Add(new Suggestion()
                        {
                            Text = suggestion,
                            IsMarked = false
                        });
                    }
                }
                else
                {
                    var keywords = tw.Keywords.Where(ke => ke.UserKeywordTags.Count() == 0);
                    int id = new Random().Next(keywords.Count());
                    var keyword = keywords.ElementAt(id);
                    //
                    task.Description = "In the above tweet, please mark the keyword  \'" + keyword.Keyword1 + "\' as one of the below";
                    task.KeywordData.Id = keyword.Id;
                    task.KeywordData.Name = keyword.Keyword1;
                    //
                    foreach (Tag t in db.Tags)
                    {
                        task.TagQuestion.Tags.Add(new Models.TagInfo()
                        {
                            IsMarked = false,
                            TagCount = 1,
                            TagId = t.Id,
                            TagName = t.Name
                        });
                    }
                }
                return task;
            }
        }

        [HttpPost]
        public void Post(CrowdTask task)
        {

        }

        public int PickTweet(bool nextSuggestion)
        {
            Tweet t = new Tweet();
            using (CrowdCorrectEntities db = new CrowdCorrectEntities())
            {
                if (!nextSuggestion)
                {
                    var keywords = db.Keywords.Where(k => k.UserKeywordTags.Count() == 0).ToList();
                    int maxValue = keywords.Count();
                    int id = new Random().Next(1, maxValue);
                    if (id == 0)
                        return id;
                    //
                    return db.Keywords.ToList().ElementAt(id).Tweet.Id;

                }
                else
                {
                    var keywords = db.Keywords.Where(k => k.UserKeywordTags.Count() > 0).ToList();
                    int id = new Random().Next(1, keywords.Count());
                    if (id == 0)
                        return id;
                    //
                    return db.Keywords.ToList().ElementAt(id).Tweet.Id;
                }
            }
        }

        private List<string> GetSuggestions(KeywordData keyword, UserKeywordTag ukt)
        {
            return new List<string>() { "a", "b", "c", "d" };
        }
    }

}
