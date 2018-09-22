using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace GoogleMini.HTMLProcessing
{
    public class HTMLProcessor
    {        
        private string pageUri;
        private Lazy<Task<HtmlDocument>> document;

        public HTMLProcessor(string pageUri = "")
        {
            this.pageUri = pageUri;
            document = new Lazy<Task<HtmlDocument>>(async () => {
                using (var httpClient = new HttpClient())
                {
                    var content = await httpClient.GetStringAsync(pageUri);
                    var doc = new HtmlDocument();
                    doc.LoadHtml(content);
                    return doc;
                }                                
            }, false);
        }

        public void LoadFromFile(string filePath)
        {
            document = new Lazy<Task<HtmlDocument>>(() =>
            {
                var doc = new HtmlDocument();
                doc.Load(filePath);
                return Task.FromResult(doc);
            }, false);
        }

        public async Task<string> GetTitleTag()
        {            
            var titleNode = (await document.Value).DocumentNode.Descendants("title").FirstOrDefault();
            return titleNode?.OuterHtml;
        }

        public async Task<IEnumerable<string>> GetAnchorTags()
        {
            return (await document.Value).DocumentNode.Descendants("a").Select(n => n.OuterHtml);
        }

        public async Task<IEnumerable<string>> GetScriptTags()
        {
            return (await document.Value).DocumentNode.Descendants("script").Select(n => n.OuterHtml);
        }        
    }
}
