IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240217064930_V1InitialCreate'
)
BEGIN
    CREATE TABLE [MaintenanceCycleTask] (
        [Id] bigint NOT NULL IDENTITY,
        [TaskName] nvarchar(max) NOT NULL,
        [TaskFrequency] int NOT NULL,
        [WeekNumber] int NULL,
        CONSTRAINT [PK_MaintenanceCycleTask] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240217064930_V1InitialCreate'
)
BEGIN
    CREATE TABLE [TaskExecutionHistory] (
        [TaskExecutionKey] bigint NOT NULL IDENTITY,
        [TaskKey] bigint NOT NULL,
        [TaskExecutionDateTime] datetime2 NOT NULL,
        [TaskNote] nvarchar(max) NULL,
        [TaskPerformedBy] nvarchar(max) NULL,
        [RowVersion] int NOT NULL,
        CONSTRAINT [PK_TaskExecutionHistory] PRIMARY KEY ([TaskExecutionKey]),
        CONSTRAINT [FK_TaskExecutionHistory_MaintenanceCycleTask_TaskKey] FOREIGN KEY ([TaskKey]) REFERENCES [MaintenanceCycleTask] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240217064930_V1InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_MaintenanceCycleTask_Id] ON [MaintenanceCycleTask] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240217064930_V1InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_TaskExecutionHistory_TaskExecutionKey] ON [TaskExecutionHistory] ([TaskExecutionKey]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240217064930_V1InitialCreate'
)
BEGIN
    CREATE INDEX [IX_TaskExecutionHistory_TaskKey] ON [TaskExecutionHistory] ([TaskKey]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240217064930_V1InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240217064930_V1InitialCreate', N'8.0.2');
END;
GO

COMMIT;
GO

