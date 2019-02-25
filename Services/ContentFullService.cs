using System.Linq;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Models.Management;
using Contentful.Core.Search;
using dotrubius.Models;
using ContentType = dotrubius.Utils.ContentType;

namespace dotrubius.Services
{
    public class ContentFullService
    {
        private IContentfulClient _contentfulClient;
        
        public ContentFullService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
        }

        public Page GetContent(ContentType contentType, string url = "index")
        {
            var builder = QueryBuilder<Page>.New
                .ContentTypeIs(contentType.ToString().ToLower()).FieldEquals(f => f.url, url);
            var result = Fetch(builder).Result;

            return result.FirstOrDefault();
        }

        private async Task<ContentfulCollection<Page>> Fetch(QueryBuilder<Page> builder)
        {
            var result = await _contentfulClient.GetEntries(builder);
            return result;
        }
    }
}