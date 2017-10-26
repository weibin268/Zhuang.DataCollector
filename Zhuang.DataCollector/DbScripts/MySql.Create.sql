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



DROP TABLE IF EXISTS `Sys_IISLog`;

CREATE TABLE Sys_IISLog
(
    Id VARCHAR(50) PRIMARY KEY,
    date DATE,
    time TIME,
    `s-ip` VARCHAR(50),
    `cs-method` VARCHAR(10),
    `cs-uri-stem` VARCHAR(500),
    `cs-uri-query` VARCHAR(500),
    `s-port` VARCHAR(10),
    `cs-username` VARCHAR(50),
    `c-ip` VARCHAR(50),
    `csUser-Agent` VARCHAR(2000),
    csReferer VARCHAR(500),
    `sc-status` VARCHAR(10),
    `sc-substatus` VARCHAR(10),
    `sc-win32-status` VARCHAR(10),
    `time-taken` VARCHAR(10),
    `ext_cs-ip` VARCHAR(500),
    CreatedDate DATETIME
);