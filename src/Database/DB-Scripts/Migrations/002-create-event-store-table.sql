create table if not exists core.eventstore(
    id uuid PRIMARY KEY NOT NULL,
    createdat Date NOT NULL,
    version int NOT NULL,
    name Varchar(250) NOT NULL,
    aggregateid uuid NOT NULL,
    data text NOT NULL
);