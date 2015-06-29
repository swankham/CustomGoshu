using Ice.Custom.UI.CostRequest;
using Ice.Lib.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice.Lib.App
{
    public class Launch : EpiBaseLaunch
    {
        protected override void InitializeLaunch()
        {
            base.UITrans = new Ice.Custom.UI.CostRequest.Transaction(this);
            base.UIForm = new RequestEstimate(base.UITrans);
        }
    }
}
