create table user
(
    id       int auto_increment
        primary key,
    username varchar(30) charset utf8mb3  null,
    name     varchar(50) charset utf8mb3  null,
    password varchar(255) charset utf8mb3 null,
    mail     varchar(50) charset utf8mb3  null,
    role     int                          null
);

create table task
(
    id          int auto_increment
        primary key,
    title       varchar(50) charset utf8mb3 not null,
    content     text                        not null,
    deadline    datetime                    null,
    status      int                         not null,
    status_date datetime                    not null,
    created_at  datetime                    not null,
    type        varchar(30) charset utf8mb3 not null,
    owner       int                         null,
    created_by  int                         null,
    constraint task_createdby_fk
        foreign key (owner) references user (id),
    constraint task_owner_fk
        foreign key (owner) references user (id)
);

create table subtask
(
    id           int auto_increment
        primary key,
    main_task_id int                         not null,
    title        varchar(50) charset utf8mb3 not null,
    content      text                        not null,
    deadline     datetime                    null,
    status       int                         not null,
    status_date  datetime                    not null,
    created_at   datetime                    not null,
    type         varchar(30) charset utf8mb3 not null,
    constraint subtask_task_id_fk
        foreign key (main_task_id) references task (id)
);