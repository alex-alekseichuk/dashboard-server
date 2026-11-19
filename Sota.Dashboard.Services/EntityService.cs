using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Sota.Dashboard.DataAccess;
using Sota.Dashboard.Services.Models;
using Sota.Dashboard.Services.Mappers;

namespace Sota.Dashboard.Services
{
  public interface IEntityService {
    IEnumerable<Entity> getEntityAttributes(int entityId);
  }
  
  public class EntityService : IEntityService {
    private readonly IEntityRepository entityRepository;

    public EntityService(IEntityRepository entityRepository) {
      this.entityRepository = entityRepository;
    }
    public IEnumerable<Entity> getEntityAttributes(int entityId) {
      return entityRepository.getEntityAttributes(entityId).Map();
    }
  }
}