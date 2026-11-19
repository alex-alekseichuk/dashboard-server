using System.Collections.Generic;
using System.Linq;
using Sota.Dashboard.Services.Mappers;
using Sota.Dashboard.Services.Models;
using Sota.Dashboard.DataAccess;

namespace Sota.Dashboard.Services
{
	public interface IObjectService
	{
		List<ObjectShortInfoDto> GetObjectsShortInfo(List<long> filterIds);
		ObjectInfoDto GetObjectInfo(long objectId);
		List<ObjectTabInfoDto> GetObjectsForTab(SelectedFiltersBlockDto selectedFilters);
	}

	public class ObjectService : IObjectService
	{
		private readonly IObjectRepository _objRepo;

		public ObjectService(IObjectRepository objRepo)
		{
			_objRepo = objRepo;
		}

		public List<ObjectShortInfoDto> GetObjectsShortInfo(List<long> filterIds)
		{
			var res = new List<ObjectShortInfoDto>();

			if (filterIds == null || !filterIds.Any()) return res;

			var obj = _objRepo.GetObjects(filterIds);
			res = obj.Map();
			return res;
		}

		public ObjectInfoDto GetObjectInfo(long objectId)
		{
			if (objectId <= 0) return null;

			var res = new ObjectInfoDto
			{
				Id = objectId,
				Props = _objRepo.GetObject(objectId, true).Map()
			};
			return res;
		}

		public List<ObjectTabInfoDto> GetObjectsForTab(SelectedFiltersBlockDto selectedFilters)
		{
			var targetSelectedValues = selectedFilters?.Values != null && selectedFilters.Values.Any()
				                           ? selectedFilters.Values.SelectMany(x => x.SelectedValues).ToList()
				                           : new List<long>();

			var data = _objRepo.GetObjectForTab(targetSelectedValues);
			return data.Map();
		}
	}
}