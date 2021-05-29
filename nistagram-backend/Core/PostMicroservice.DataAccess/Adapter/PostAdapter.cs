using PostMicroservice.DataAccess.Adaptee;
using PostMicroservice.DataAccess.Target;
using System.Data;

namespace PostMicroservice.DataAccess.Adapter
{
    public class PostAdapter : ITarget
    {
        private readonly PostAdaptee postAdaptee;

        public PostAdapter(PostAdaptee postAdaptee)
        {
            this.postAdaptee = postAdaptee;
        }

        public object ConvertSql(DataRow dataRow)
        {
            return postAdaptee.ConvertSqlDataReaderToPost(dataRow);
        }
    }
}