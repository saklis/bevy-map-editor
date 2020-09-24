using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BevyEditor.Proto;
using Grpc.Core;

namespace Process_Parent_Test
{
    public class BevyEditorService : BevyEditor.Proto.BevyEditorService.BevyEditorServiceBase
    {
        public override Task<VoidResult> MoveCube(AxisX request, ServerCallContext conext)
        {

        }
    }
}
