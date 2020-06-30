﻿using GraphQL;
using GraphQL.Types;

namespace Api.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AuthorQuery>();
        }
    }
}