terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "4.5.0"
    }
  }
}

provider "azurerm" {
  features {}
  subscription_id = "b6636dea-0304-4d08-abb7-c30525fe92f0"
}

resource "azurerm_resource_group" "taskflow_rg" {
  name     = "taskflow-rg"
  location = var.location
}

/* resource "azurerm_app_service_plan" "taskflow_asp" {
  name                = "taskflow-asp"
  location            = azurerm_resource_group.taskflow_rg.location
  resource_group_name = azurerm_resource_group.taskflow_rg.name
  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "taskflow_api" {
  name                = "taskflow-api"
  location            = azurerm_resource_group.taskflow_rg.location
  resource_group_name = azurerm_resource_group.taskflow_rg.name
  app_service_plan_id = azurerm_app_service_plan.taskflow_asp.id

  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "1"
  }

  site_config {
    scm_type = "LocalGit"
  }
}

resource "azurerm_mssql_server" "taskflow_sql" {
  name                         = "taskflow-sqlserver"
  resource_group_name          = azurerm_resource_group.taskflow_rg.name
  location                     = azurerm_resource_group.taskflow_rg.location
  version                      = "12.0"
  administrator_login          = var.sql_admin_username
  administrator_login_password = var.sql_admin_password
}

resource "azurerm_mssql_database" "taskflow_db" {
  server_id = azurerm_mssql_server.taskflow_sql.id
  name                = "taskflowdb"
  sku_name            = "Basic"
}

resource "azurerm_storage_account" "taskflow_storage" {
  name                     = "taskflowstorageacc"
  resource_group_name      = azurerm_resource_group.taskflow_rg.name
  location                 = azurerm_resource_group.taskflow_rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_blob" "taskflow_blob" {
  name                   = "taskflowcode.zip"
  storage_account_name   = azurerm_storage_account.taskflow_storage.name
  storage_container_name = azurerm_storage_container.taskflow_container.name
  type                   = "Block"
  source                 = "https://github.com/luizambrozini/TaskFlow/archive/main.zip"
}

resource "azurerm_storage_container" "taskflow_container" {
  name                  = "taskflowcontainer"
  storage_account_name  = azurerm_storage_account.taskflow_storage.name
  container_access_type = "private"
}
 */