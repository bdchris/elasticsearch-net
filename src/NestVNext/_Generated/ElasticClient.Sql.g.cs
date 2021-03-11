// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.
//
// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗ 
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝ 
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗   
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝   
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗ 
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝ 
// ------------------------------------------------
//
// This file is automatically generated.
// Please do not edit these files manually.
// Run the following in the root of the repository:
//
// TODO - RUN INSTRUCTIONS
//
// ------------------------------------------------
using System;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Transport;

namespace Nest
{
    public class SqlNamespace : NamespacedClientProxy
    {
        internal SqlNamespace(ElasticClient client): base(client)
        {
        }

        public ClearSqlCursorResponse ClearSqlCursor(IClearSqlCursorRequest request)
        {
            return DoRequest<IClearSqlCursorRequest, ClearSqlCursorResponse>(request, request.RequestParameters);
        }

        public Task<ClearSqlCursorResponse> ClearSqlCursorAsync(IClearSqlCursorRequest request, CancellationToken cancellationToken = default)
        {
            return DoRequestAsync<IClearSqlCursorRequest, ClearSqlCursorResponse>(request, request.RequestParameters, cancellationToken);
        }

        public QuerySqlResponse QuerySql(IQuerySqlRequest request)
        {
            return DoRequest<IQuerySqlRequest, QuerySqlResponse>(request, request.RequestParameters);
        }

        public Task<QuerySqlResponse> QuerySqlAsync(IQuerySqlRequest request, CancellationToken cancellationToken = default)
        {
            return DoRequestAsync<IQuerySqlRequest, QuerySqlResponse>(request, request.RequestParameters, cancellationToken);
        }

        public TranslateSqlResponse TranslateSql(ITranslateSqlRequest request)
        {
            return DoRequest<ITranslateSqlRequest, TranslateSqlResponse>(request, request.RequestParameters);
        }

        public Task<TranslateSqlResponse> TranslateSqlAsync(ITranslateSqlRequest request, CancellationToken cancellationToken = default)
        {
            return DoRequestAsync<ITranslateSqlRequest, TranslateSqlResponse>(request, request.RequestParameters, cancellationToken);
        }
    }
}