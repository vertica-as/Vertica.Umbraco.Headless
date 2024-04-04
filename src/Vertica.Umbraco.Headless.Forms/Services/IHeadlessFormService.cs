using System;
using System.Collections.Generic;
using Umbraco.Forms.Core.Models;
using Vertica.Umbraco.Headless.Forms.Models;

namespace Vertica.Umbraco.Headless.Forms.Services
{
    public interface IHeadlessFormService
    {
        public FormViewModel? Get(Guid id);
        public FormViewModel? Get(string name);
        public IEnumerable<FormViewModel?> Get(Guid[] ids);
        public IEnumerable<FormViewModel?> Get();
        public FormViewModel? Convert(Form form);
    }
}