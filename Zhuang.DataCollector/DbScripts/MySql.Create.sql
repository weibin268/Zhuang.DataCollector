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



DROP TABLE IF EXISTS Sys_IISLog;

CREATE TABLE Sys_IISLog
(
    Id VARCHAR(50) PRIMARY KEY,
    date DATE,
    time TIME,
    s_ip VARCHAR(50),
    cs_method VARCHAR(10),
    cs_uri_stem VARCHAR(500),
    cs_uri_query VARCHAR(500),
    s_port VARCHAR(10),
    cs_username VARCHAR(50),
    c_ip VARCHAR(50),
    csUser_Agent VARCHAR(2000),
    csReferer VARCHAR(500),
    sc_status VARCHAR(10),
    sc_substatus VARCHAR(10),
    sc_win32_status VARCHAR(10),
    time_taken VARCHAR(10),
    ext_cs_ip VARCHAR(500),
    CreatedDate DATETIME
);