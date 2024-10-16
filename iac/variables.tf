variable "location" {
  description = "Location for Azure resources"
  default     = "East US"
}

variable "sql_admin_username" {
  description = "SQL Server admin username"
  default     = "taskflow"
}

variable "sql_admin_password" {
  description = "SQL Server admin password"
  default     = "T4skflow2015@"
  sensitive   = true
}
