using CampaignService.DataAccess.Adaptee;
using CampaignService.DataAccess.Target;
using System.Data;

namespace CampaignService.DataAccess.Adapter
{
    public class AgentAdapter /*: ITarget*/
    {
        private readonly AgentAdaptee agentAdaptee;

        public AgentAdapter(AgentAdaptee agentAdaptee)
        {
            this.agentAdaptee = agentAdaptee;
        }

        /*public object ConvertSql(DataRow dataRow)
        {
            return agentAdaptee.ConvertSqlDataReaderToAgent(dataRow);
        }*/
    }
}