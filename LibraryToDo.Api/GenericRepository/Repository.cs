using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Reflection;

namespace LibraryToDo.GenericRepository
{
	using static Dapper.SqlMapper;
	using Microsoft.Data.SqlClient;
    using Renci.SshNet.Common;
    using LibraryToDo.Models.Db.Context;
    using LibraryToDo.Constants;
    using LibraryToDo.Helpers;

    public class Repository<T> : IRepository<T> where T : class
	{
		private readonly IDbConnection ctx;
		private readonly LibraryToDoDbContext _libraryToDoDbContext;

		public Repository(LibraryToDoDbContext libraryToDoDbContext)
		{
			_libraryToDoDbContext = libraryToDoDbContext;
			ctx = _libraryToDoDbContext.CreateConnection();
		}

		public async Task<bool> Delete(Guid Id)
		{
			var table = typeof(T).Name + "s";
			var entity = await ctx.QueryFirstAsync<T>($"Select * From {table} Where Id='{Id}'");
			if (entity == null)
				throw new AppException(ProjectConstants.GENERIC_DELETE_ERROR, ProjectConstants.ERROR_CODE_19);
			return await ctx.DeleteAsync<T>(entity);
		}

		public async Task<List<T>> GetAll()
		{
			var table = typeof(T).Name + "s";
			var result = await ctx.QueryAsync<T>($"Select * From {table}");
			return result.ToList();
		}

        public async Task<T> GetById(Guid Id)
        {
            if (ctx.State == ConnectionState.Closed || ctx.State == ConnectionState.Connecting)
                await ((SqlConnection)ctx).OpenAsync();

            var table = typeof(T).Name + "s";
            return await ctx.QueryFirstAsync<T>($"Select * From {table} Where Id='{Id}'");
        }


        Type entityType = null;
		public async Task<T> Insert(T model)
		{
            try
            {
                var entity = await ctx.InsertAsync<T>(model);

                return model;
            }
            catch (Exception ex)
            {

                throw new AppException(ProjectConstants.GENERIC_INSERT_ERROR, ProjectConstants.ERROR_CODE_18);
            }
        }

		public async Task<T> Update(T model)
		{
            try
            {
                var entity = await ctx.UpdateAsync(model);

                if (!entity)
                {
                    throw new AppException(ProjectConstants.GENERIC_UPDATE_ERROR, ProjectConstants.ERROR_CODE_21);
                }
                return model;

            }
            catch (Exception)
            {

                throw new AppException(ProjectConstants.GENERIC_UPDATE_ERROR, ProjectConstants.ERROR_CODE_21);
            }
        }
	}
}
