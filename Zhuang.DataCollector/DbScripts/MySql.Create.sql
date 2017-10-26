DROP TABLE IF EXISTS `Sys_ReadDataLog`;

CREATE TABLE Sys_ReadDataLog
(
    Id VARCHAR(50) PRIMARY KEY,
    DataPath VARCHAR(500) NOT NULL,
    CursorPosition LONG NOT NULL,
    RuleText VARCHAR(1000),
    CreatedDate DATETIME NOT NULL,
    ModifiedDate DATETIME
);