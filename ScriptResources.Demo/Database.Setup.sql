CREATE TABLE IF NOT EXISTS  DemoData {
     id TEXT not null unique default (hex(randomblob(16))),
    name TEXT NOT NULL UNIQUE,
    displayName TEXT NOT NULL,
    description TEXT NOT NULL,
    email TEXT NOT NULL,    
    disabled BIT not null default 0,
    createdAt DATETIME not null default (datetime('now')),
    updatedAt DATETIME not null default (datetime('now'))
}
GO
INSERT OR IGNORE INTO DemoData (
    id ,
    name ,
    displayName,
    description,
    email)
) values 
( 'x', 'x', 'X', 'X x', 'x@x'),
( 'y', 'y', 'Y', 'y y', 'y@y');
GO