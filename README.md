# GraphQL-Example-1
 
 Query Example

 http://localhost:54359/graphql

 { 
    authors {
        name,
        books {
            id,
            name, 
            genre
        }
    }
}