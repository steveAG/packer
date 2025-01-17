#load "src/core/cake/core.cake"

var target = Argument("target", "default");
var configuration = Argument("configuration", string.Empty);
var recursive = Argument("recursive", false);
var version = "2306";

var buildDirectory = Argument("build-directory", "./build");
PackerTemplate.BuildDirectory = buildDirectory;

var ws2022s = PackerTemplates_CreateWindows(
  "ws2022s",
  "windows-server-2022-standard",
  $"2102.0.{version}",
  aliases: new [] { "windows-server" }
);
var ws2022s_nocm = PackerTemplates_CreateWindows(
  "ws2022s-nocm",
  "windows-server-2022-standard-nocm",
  $"2102.0.{version}",
  ws2022s
);
var ws2019s = PackerTemplates_CreateWindows(
  "ws2019s",
  "windows-server-2019-standard",
  $"1809.0.{version}"
);
var wsips = PackerTemplates_CreateWindows(
  "wsips",
  "windows-server-insider-preview-standard",
  $"2102.0.{version}"
);

var ws2022sc = PackerTemplates_CreateWindows(
  "ws2022sc",
  "windows-server-2022-standard-core",
  $"2102.0.{version}",
  aliases: new [] { "windows-server-core" }
);
var ws2019sc = PackerTemplates_CreateWindows(
  "ws2019sc",
  "windows-server-2019-standard-core",
  $"1809.0.{version}"
);
var wsipsc = PackerTemplates_CreateWindows(
  "wsipsc",
  "windows-server-insider-preview-standard-core",
  $"2102.0.{version}"
);

var w1122h2e = PackerTemplates_CreateWindows(
  "w1122h2e",
  "windows-11-22h2-enterprise",
  $"2202.0.{version}",
  aliases: new [] { "windows-11" }
);
var w1121h2e = PackerTemplates_CreateWindows(
  "w1121h2e",
  "windows-11-21h2-enterprise",
  $"2102.0.{version}"
);
var w11ipe = PackerTemplates_CreateWindows(
  "w11ipe",
  "windows-11-insider-preview-enterprise",
  $"2202.0.{version}"
);

var w1022h2e = PackerTemplates_CreateWindows(
  "w1022h2e",
  "windows-10-22h2-enterprise",
  $"2202.0.{version}",
  aliases: new [] { "windows-10" }
);
var w1022h2e_nocm = PackerTemplates_CreateWindows(
  "w1022h2e-nocm",
  "windows-10-22h2-enterprise-nocm",
  $"2202.0.{version}",
  w1022h2e
);
var w1021h2e = PackerTemplates_CreateWindows(
  "w1021h2e",
  "windows-10-21h2-enterprise",
  $"2102.0.{version}"
);
var w1021h2eltsc = PackerTemplates_CreateWindows(
  "w1021h2eltsc",
  "windows-10-21h2-enterprise-ltsc",
  $"2102.0.{version}"
);
var w101809eltsc = PackerTemplates_CreateWindows(
  "w101809eltsc",
  "windows-10-1809-enterprise-ltsc",
  $"1809.0.{version}"
);
var w10ipe = PackerTemplates_CreateWindows(
  "w10ipe",
  "windows-10-insider-preview-enterprise",
  $"2202.0.{version}"
);

var u2004s = PackerTemplates_CreateLinux(
  "u2004s",
  "ubuntu-server-2004-lts",
  $"2004.0.{version}",
  aliases: new [] { "ubuntu-server" }
);

var u2004d = PackerTemplates_CreateLinux(
  "u2004d",
  "ubuntu-desktop-2004-lts-xfce",
  $"2004.0.{version}",
  u2004s,
  aliases: new [] { "ubuntu-desktop" }
);

var ws2022s_dc = PackerTemplates_CreateWindows(
  "ws2022s-dc",
  "docker-community-windows-server",
  $"2400.2102.{version}",
  ws2022s,
  aliases: new [] { "docker-windows" }
);
var ws2022sc_dc = PackerTemplates_CreateWindows(
  "ws2022sc-dc",
  "docker-community-windows-server-core",
  $"2400.2102.{version}",
  ws2022sc
);
var u2004s_dc = PackerTemplates_CreateLinux(
  "u2004s-dc",
  "docker-community-ubuntu-server",
  $"2400.2004.{version}",
  u2004s,
  aliases: new [] { "docker-linux" }
);

var ws2022s_iis = PackerTemplates_CreateWindows(
  "ws2022s-iis",
  "iis-windows-server",
  $"10.2102.{version}",
  ws2022s,
  aliases: new [] { "iis" }
);
var ws2022sc_iis = PackerTemplates_CreateWindows(
  "ws2022sc-iis",
  "iis-windows-server-core",
  $"10.2102.{version}",
  ws2022sc
);

var ws2022s_sql19d = PackerTemplates_CreateWindows(
  "ws2022s-sql19d",
  "sql-server-2019-developer-windows-server",
  $"2019.2102.{version}",
  ws2022s,
  aliases: new [] { "sql-server" }
);
var ws2022sc_sql19d = PackerTemplates_CreateWindows(
  "ws2022sc-sql19d",
  "sql-server-2019-developer-windows-server-core",
  $"2019.2102.{version}",
  ws2022sc
);

var w1122h2e_vs22c = PackerTemplates_CreateWindows(
  "w1122h2e-vs22c",
  "visual-studio-2022-community-windows-11",
  $"2022.2202.{version}",
  w1122h2e,
  aliases: new [] { "visual-studio" }
);
var w1022h2e_vs22c = PackerTemplates_CreateWindows(
  "w1022h2e-vs22c",
  "visual-studio-2022-community-windows-10",
  $"2022.2202.{version}",
  w1022h2e
);
var w1122h2e_vs19c = PackerTemplates_CreateWindows(
  "w1122h2e-vs19c",
  "visual-studio-2019-community-windows-11",
  $"2019.2202.{version}",
  w1122h2e
);
var w1022h2e_vs19c = PackerTemplates_CreateWindows(
  "w1022h2e-vs19c",
  "visual-studio-2019-community-windows-10",
  $"2019.2202.{version}",
  w1022h2e
);

Task("default")
  .IsDependentOn("info");

Task("info")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Info);
  });

Task("version")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Version);
  });

Task("restore")
  .IsDependentOn("version")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Restore);
  });

Task("build")
  .IsDependentOn("restore")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Build);
  });

Task("rebuild")
  .IsDependentOn("clean")
  .IsDependentOn("build")
  .Does(() => {
  });

Task("test")
  .IsDependentOn("build")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Test);
  });

Task("package")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Package);
  });

Task("publish")
  .IsDependentOn("package")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Publish);
  });

Task("download")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Download);
  });

Task("clean")
  .IsDependentOn("version")
  .Does(() => {
    PackerTemplates_ForEach(configuration, PackerTemplate_Clean);
  });

RunTarget(target);
