// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    public partial class KeyVaultRoleDefinition : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(RoleName))
            {
                writer.WritePropertyName("roleName");
                writer.WriteStringValue(RoleName);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(RoleType))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(RoleType.Value.ToString());
            }
            if (Optional.IsCollectionDefined(Permissions))
            {
                writer.WritePropertyName("permissions");
                writer.WriteStartArray();
                foreach (var item in Permissions)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AssignableScopes))
            {
                writer.WritePropertyName("assignableScopes");
                writer.WriteStartArray();
                foreach (var item in AssignableScopes)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static KeyVaultRoleDefinition DeserializeKeyVaultRoleDefinition(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<KeyVaultRoleDefinitionType> type = default;
            Optional<string> roleName = default;
            Optional<string> description = default;
            Optional<KeyVaultRoleType> type0 = default;
            Optional<IList<KeyVaultPermission>> permissions = default;
            Optional<IList<KeyVaultRoleScope>> assignableScopes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new KeyVaultRoleDefinitionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("roleName"))
                        {
                            roleName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("description"))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("type"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            type0 = new KeyVaultRoleType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("permissions"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<KeyVaultPermission> array = new List<KeyVaultPermission>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(KeyVaultPermission.DeserializeKeyVaultPermission(item));
                            }
                            permissions = array;
                            continue;
                        }
                        if (property0.NameEquals("assignableScopes"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<KeyVaultRoleScope> array = new List<KeyVaultRoleScope>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new KeyVaultRoleScope(item.GetString()));
                            }
                            assignableScopes = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new KeyVaultRoleDefinition(id.Value, name.Value, Optional.ToNullable(type), roleName.Value, description.Value, Optional.ToNullable(type0), Optional.ToList(permissions), Optional.ToList(assignableScopes));
        }
    }
}
