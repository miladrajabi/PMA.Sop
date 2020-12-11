using System.Collections.Generic;
using PMA.Sop.Framework.Resources.Interface;

namespace PMA.Sop.Framework.Dtos
{
    public class ResultDto
    {
        private readonly IResourceManager _resourceManager;

        public ResultDto(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }
        public ResultDto()
        {
        }

        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        private readonly List<string> _errors = new List<string>();

        public IEnumerable<string> Errors => _errors;
        public void AddError(string error)
        {
            IsSuccess = false;
            _errors.Add(_resourceManager[error]);
        }
        public void AddError(string error, params string[] arguments)
        {
            _errors.Add(_resourceManager[error, arguments]);
        }
        public void ClearErrors()
        {
            _errors.Clear();
        }
    }
    public class ResultDto<T> : ResultDto
    {

        public ResultDto(IResourceManager resourceManager) : base(resourceManager)
        {
        }
        public T Data { get; set; }

    }
}