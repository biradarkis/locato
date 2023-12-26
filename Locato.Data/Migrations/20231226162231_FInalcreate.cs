using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locato.Data.Migrations
{
    /// <inheritdoc />
    public partial class FInalcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attachments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    file_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false),
                    thumbnail = table.Column<byte[]>(type: "bytea", nullable: false),
                    thumbnail_key = table.Column<string>(type: "character varying(40)", unicode: false, maxLength: 40, nullable: false),
                    storage_url = table.Column<string>(type: "text", nullable: false),
                    thumbnail_storage_url = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attachments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "base_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    account_status = table.Column<string>(type: "text", nullable: false),
                    login_attempts = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_base_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    middle_name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sex = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "push_notification",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_push_notification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "static_medias",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    file_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    uri = table.Column<string>(type: "character varying(512)", unicode: false, maxLength: 512, nullable: false),
                    key = table.Column<string>(type: "character varying(128)", unicode: false, maxLength: 128, nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false),
                    storage_url = table.Column<string>(type: "text", nullable: false),
                    processed = table.Column<bool>(type: "boolean", nullable: false),
                    is_ready = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_static_medias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    profile_id = table.Column<long>(type: "bigint", nullable: false),
                    key = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    mime_type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    raw_bytes = table.Column<byte[]>(type: "bytea", nullable: false),
                    thumbnail_large_key = table.Column<string>(type: "text", nullable: false),
                    thumbnail_large = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_photos", x => x.profile_id);
                    table.ForeignKey(
                        name: "fk_photos_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: false),
                    phone_country_code = table.Column<int>(type: "integer", nullable: false),
                    phone_national_number = table.Column<long>(type: "bigint", nullable: false),
                    phone_raw_input = table.Column<string>(type: "text", nullable: false),
                    phone_e164format = table.Column<long>(type: "bigint", nullable: false),
                    alternate_phone_country_code = table.Column<int>(type: "integer", nullable: false),
                    alternate_phone_national_number = table.Column<long>(type: "bigint", nullable: false),
                    alternate_phone_raw_input = table.Column<string>(type: "text", nullable: false),
                    alternate_phone_e164format = table.Column<long>(type: "bigint", nullable: false),
                    address_latitude = table.Column<double>(type: "double precision", nullable: false),
                    address_longitude = table.Column<double>(type: "double precision", nullable: false),
                    address_street = table.Column<string>(type: "text", nullable: false),
                    address_city = table.Column<string>(type: "text", nullable: false),
                    address_state = table.Column<string>(type: "text", nullable: false),
                    address_zip = table.Column<string>(type: "text", nullable: false),
                    address_country = table.Column<string>(type: "text", nullable: false),
                    website = table.Column<string>(type: "text", nullable: false),
                    api_url = table.Column<string>(type: "text", nullable: false),
                    logo_id = table.Column<long>(type: "bigint", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    locale = table.Column<string>(type: "text", nullable: false),
                    currency = table.Column<string>(type: "text", nullable: false),
                    pan_number = table.Column<string>(type: "text", nullable: false),
                    tan_number = table.Column<string>(type: "text", nullable: false),
                    gst_number = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizations_static_medias_logo_id",
                        column: x => x.logo_id,
                        principalTable: "static_medias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "organization_off_days",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    off_day = table.Column<int>(type: "integer", nullable: false),
                    organization_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_off_days", x => x.id);
                    table.ForeignKey(
                        name: "fk_organization_off_days_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tracker_devices",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    identity = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: false),
                    org_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tracker_devices", x => x.id);
                    table.ForeignKey(
                        name: "fk_tracker_devices_organizations_organization_id",
                        column: x => x.org_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orgtrackerdevices",
                columns: table => new
                {
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: false),
                    organization_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orgtrackerdevices", x => new { x.tracker_device_id, x.organization_id });
                    table.ForeignKey(
                        name: "fk_orgtrackerdevices_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orgtrackerdevices_tracker_devices_tracker_device_id",
                        column: x => x.tracker_device_id,
                        principalTable: "tracker_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tracker_device_alarms",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: false),
                    location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    alarm_type = table.Column<int>(type: "integer", nullable: false),
                    meta = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tracker_device_alarms", x => x.id);
                    table.ForeignKey(
                        name: "fk_tracker_device_alarms_tracker_devices_tracker_device_id",
                        column: x => x.tracker_device_id,
                        principalTable: "tracker_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trackerlocations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: false),
                    location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    speed = table.Column<int>(type: "integer", nullable: true),
                    information_length = table.Column<int>(type: "integer", nullable: true),
                    satellites_used = table.Column<int>(type: "integer", nullable: true),
                    serial_number = table.Column<long>(type: "bigint", nullable: true),
                    acc = table.Column<bool>(type: "boolean", nullable: true),
                    real_time_gps = table.Column<bool>(type: "boolean", nullable: true),
                    east_longitude = table.Column<bool>(type: "boolean", nullable: true),
                    north_latitude = table.Column<bool>(type: "boolean", nullable: true),
                    course = table.Column<int>(type: "integer", nullable: true),
                    voltage = table.Column<double>(type: "double precision", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trackerlocations", x => x.id);
                    table.ForeignKey(
                        name: "fk_trackerlocations_tracker_devices_tracker_device_id",
                        column: x => x.tracker_device_id,
                        principalTable: "tracker_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "email_notifications",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    email_id = table.Column<string>(type: "text", nullable: false),
                    notification_type = table.Column<string>(type: "text", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    retries = table.Column<int>(type: "integer", nullable: false),
                    is_sucess = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_email_notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_holiday = table.Column<bool>(type: "boolean", nullable: false),
                    media_id = table.Column<long>(type: "bigint", nullable: true),
                    organization_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    route_id = table.Column<long>(type: "bigint", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    isuserevent = table.Column<bool>(type: "boolean", nullable: false),
                    isorgevent = table.Column<bool>(type: "boolean", nullable: false),
                    isrouteevent = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_events_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_events_static_medias_media_id",
                        column: x => x.media_id,
                        principalTable: "static_medias",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "login_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_login_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    delivered = table.Column<bool>(type: "boolean", nullable: false),
                    expired_before_seen = table.Column<bool>(type: "boolean", nullable: false),
                    trip_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    for_user_id = table.Column<long>(type: "bigint", nullable: true),
                    is_unicode_sms = table.Column<bool>(type: "boolean", nullable: false),
                    deliver_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    attachment_id = table.Column<long>(type: "bigint", nullable: true),
                    Text = table.Column<byte[]>(type: "bytea", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_messages", x => x.id);
                    table.ForeignKey(
                        name: "fk_messages_attachments_attachment_id",
                        column: x => x.attachment_id,
                        principalTable: "attachments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "route_stop_geo_fences",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    route_stop_id = table.Column<long>(type: "bigint", nullable: false),
                    radius_in_meters = table.Column<double>(type: "double precision", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_stop_geo_fences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "route_stops",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    place_id = table.Column<string>(type: "text", nullable: false),
                    coordinate_latitude = table.Column<double>(type: "double precision", nullable: false),
                    coordinate_longitude = table.Column<double>(type: "double precision", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    route_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_stops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "route_timings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    route_id = table.Column<long>(type: "bigint", nullable: false),
                    start_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vehicle_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route_timings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routegeofencecords",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    route_id = table.Column<long>(type: "bigint", nullable: false),
                    geofence_point_latitude = table.Column<double>(type: "double precision", nullable: false),
                    geofence_point_longitude = table.Column<double>(type: "double precision", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routegeofencecords", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    start_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    end_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    on_time_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    on_time_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    organization_id = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_id = table.Column<long>(type: "bigint", nullable: false),
                    start_location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    start_location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    start_location_address = table.Column<string>(type: "text", nullable: false),
                    start_location_place_id = table.Column<string>(type: "text", nullable: false),
                    end_location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    end_location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    end_location_address = table.Column<string>(type: "text", nullable: false),
                    end_location_place_id = table.Column<string>(type: "text", nullable: false),
                    track = table.Column<string>(type: "text", nullable: false),
                    average_speed = table.Column<int>(type: "integer", nullable: false),
                    notify_on_trip_start = table.Column<bool>(type: "boolean", nullable: false),
                    notify_on_trip_stop = table.Column<bool>(type: "boolean", nullable: false),
                    notify_for_eta = table.Column<bool>(type: "boolean", nullable: false),
                    calculate_eta = table.Column<bool>(type: "boolean", nullable: false),
                    drawn_route = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: false),
                    modified_by = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routes", x => x.id);
                    table.ForeignKey(
                        name: "fk_routes_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_country_code = table.Column<int>(type: "integer", nullable: false),
                    phone_national_number = table.Column<long>(type: "bigint", nullable: false),
                    phone_raw_input = table.Column<string>(type: "text", nullable: false),
                    phone_e164format = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    alternate_phone_country_code = table.Column<int>(type: "integer", nullable: false),
                    alternate_phone_national_number = table.Column<long>(type: "bigint", nullable: false),
                    alternate_phone_raw_input = table.Column<string>(type: "text", nullable: false),
                    alternate_phone_e164format = table.Column<long>(type: "bigint", nullable: false),
                    last_seen = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    profile_id = table.Column<long>(type: "bigint", nullable: false),
                    email_verified = table.Column<bool>(type: "boolean", nullable: false),
                    phone_verified = table.Column<bool>(type: "boolean", nullable: false),
                    account_status = table.Column<string>(type: "text", nullable: false),
                    base_user_id = table.Column<long>(type: "bigint", nullable: false),
                    location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    location_street = table.Column<string>(type: "text", nullable: false),
                    location_city = table.Column<string>(type: "text", nullable: false),
                    location_state = table.Column<string>(type: "text", nullable: false),
                    location_zip = table.Column<string>(type: "text", nullable: false),
                    location_country = table.Column<string>(type: "text", nullable: false),
                    route_id = table.Column<long>(type: "bigint", nullable: false),
                    organization_id = table.Column<long>(type: "bigint", nullable: false),
                    designation = table.Column<string>(type: "text", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_base_users_base_user_id",
                        column: x => x.base_user_id,
                        principalTable: "base_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sms_notification",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sms_notification", x => x.id);
                    table.ForeignKey(
                        name: "fk_sms_notification_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trip_subscribers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    subscriber_id = table.Column<long>(type: "bigint", nullable: false),
                    connection_id = table.Column<string>(type: "text", nullable: false),
                    source = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip_subscribers", x => x.id);
                    table.ForeignKey(
                        name: "fk_trip_subscribers_users_subscriber_id",
                        column: x => x.subscriber_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    start_location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    start_location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    end_location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    end_location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    last_known_location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    last_known_location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    driver_id = table.Column<long>(type: "bigint", nullable: true),
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: true),
                    route_id = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_license_number = table.Column<string>(type: "text", nullable: false),
                    in_progress = table.Column<bool>(type: "boolean", nullable: false),
                    end_reason = table.Column<string>(type: "text", nullable: false),
                    started_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ended_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    distance_travelled = table.Column<double>(type: "double precision", nullable: true),
                    timing_status = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trips", x => x.id);
                    table.ForeignKey(
                        name: "fk_trips_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_trips_tracker_devices_tracker_device_id",
                        column: x => x.tracker_device_id,
                        principalTable: "tracker_devices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_trips_users_driver_id",
                        column: x => x.driver_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_device_infoes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    device_token = table.Column<string>(type: "text", nullable: false),
                    os_version = table.Column<string>(type: "text", nullable: false),
                    device_type = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_device_infoes", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_device_infoes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_ot_ps",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    otp = table.Column<int>(type: "integer", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_ot_ps", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_ot_ps_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usertemppass",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    base_user_id = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    valid_till = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usertemppass", x => x.id);
                    table.ForeignKey(
                        name: "fk_usertemppass_base_users_base_user_id",
                        column: x => x.base_user_id,
                        principalTable: "base_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usertemppass_users_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    registration_number = table.Column<string>(type: "text", nullable: false),
                    vehicle_type = table.Column<string>(type: "text", nullable: false),
                    seat_capacity = table.Column<int>(type: "integer", nullable: false),
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: true),
                    busdriver_id = table.Column<long>(type: "bigint", nullable: false),
                    owned_by_org = table.Column<bool>(type: "boolean", nullable: false),
                    bgv = table.Column<bool>(type: "boolean", nullable: false),
                    cctv = table.Column<bool>(type: "boolean", nullable: false),
                    fire_extinguisher = table.Column<bool>(type: "boolean", nullable: false),
                    first_aid_box = table.Column<bool>(type: "boolean", nullable: false),
                    org_id = table.Column<long>(type: "bigint", nullable: false),
                    engine_number = table.Column<string>(type: "text", nullable: false),
                    model_name_and_number = table.Column<string>(type: "text", nullable: false),
                    make_year = table.Column<int>(type: "integer", nullable: true),
                    speed_limit = table.Column<int>(type: "integer", nullable: true),
                    chassis_number = table.Column<string>(type: "text", nullable: false),
                    insurance_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    insurance_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    permit_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    permit_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tax_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tax_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_permit_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    org_permit_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fitness_certificate_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fitness_certificate_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fire_extinguisher_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fire_extinguisher_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    first_aid_box_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    first_aid_box_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    vehicle_next_inspection_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fuel_type = table.Column<string>(type: "text", nullable: false),
                    odometer_reading = table.Column<double>(type: "double precision", nullable: true),
                    is_blackedout = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicles_organizations_organization_id",
                        column: x => x.org_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_users_busdriver_id",
                        column: x => x.busdriver_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip_active_geo_fences",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    trip_id = table.Column<long>(type: "bigint", nullable: false),
                    stop_geofence_id = table.Column<long>(type: "bigint", nullable: false),
                    first_coordinate_latitude = table.Column<double>(type: "double precision", nullable: false),
                    first_coordinate_longitude = table.Column<double>(type: "double precision", nullable: false),
                    last_known_coordinate_latitude = table.Column<double>(type: "double precision", nullable: false),
                    last_known_coordinate_longitude = table.Column<double>(type: "double precision", nullable: false),
                    geofence_status = table.Column<string>(type: "text", nullable: false),
                    entry_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip_active_geo_fences", x => x.id);
                    table.ForeignKey(
                        name: "fk_trip_active_geo_fences_route_stop_geo_fences_stop_geofence_",
                        column: x => x.stop_geofence_id,
                        principalTable: "route_stop_geo_fences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trip_active_geo_fences_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip_locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    trip_id = table.Column<long>(type: "bigint", nullable: false),
                    location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip_locations", x => x.id);
                    table.ForeignKey(
                        name: "fk_trip_locations_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip_notifications",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    trip_id = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip_notifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_trip_notifications_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trip_notifications_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_alerts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    org_bus_id = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_id = table.Column<long>(type: "bigint", nullable: false),
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    location_latitude = table.Column<double>(type: "double precision", nullable: false),
                    location_longitude = table.Column<double>(type: "double precision", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    alert_type = table.Column<string>(type: "text", nullable: false),
                    tracker_device_alarm_id = table.Column<long>(type: "bigint", nullable: true),
                    trip_id = table.Column<long>(type: "bigint", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_alerts", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_alerts_tracker_device_alarms_tracker_device_alarm_id",
                        column: x => x.tracker_device_alarm_id,
                        principalTable: "tracker_device_alarms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicle_alerts_tracker_devices_tracker_device_id",
                        column: x => x.tracker_device_id,
                        principalTable: "tracker_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicle_alerts_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicle_alerts_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_distance_traveled",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_id = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    trip_id = table.Column<long>(type: "bigint", nullable: false),
                    distance_traveled = table.Column<double>(type: "double precision", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_distance_traveled", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_distance_traveled_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicle_distance_traveled_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_medias",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_id = table.Column<long>(type: "bigint", nullable: false),
                    file_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_medias", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_medias_static_medias_file_id",
                        column: x => x.file_id,
                        principalTable: "static_medias",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicle_medias_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehicletdlogs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    vehicle_id = table.Column<long>(type: "bigint", nullable: false),
                    tracker_device_id = table.Column<long>(type: "bigint", nullable: false),
                    log_entry_type = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicletdlogs", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicletdlogs_tracker_devices_tracker_device_id",
                        column: x => x.tracker_device_id,
                        principalTable: "tracker_devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicletdlogs_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_alert_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    alert_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    read_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_alert_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_alert_users_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicle_alert_users_vehicle_alerts_alert_id",
                        column: x => x.alert_id,
                        principalTable: "vehicle_alerts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_email_notifications_user_id",
                table: "email_notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_media_id",
                table: "events",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_organization_id",
                table: "events",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_route_id",
                table: "events",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_user_id",
                table: "events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_login_users_user_id",
                table: "login_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_messages_attachment_id",
                table: "messages",
                column: "attachment_id");

            migrationBuilder.CreateIndex(
                name: "ix_messages_created_by_id",
                table: "messages",
                column: "created_by_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_messages_for_user_id",
                table: "messages",
                column: "for_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_messages_trip_id",
                table: "messages",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_messages_user_id",
                table: "messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_off_days_organization_id",
                table: "organization_off_days",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_organizations_logo_id",
                table: "organizations",
                column: "logo_id");

            migrationBuilder.CreateIndex(
                name: "ix_orgtrackerdevices_organization_id",
                table: "orgtrackerdevices",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_route_stop_geo_fences_route_stop_id",
                table: "route_stop_geo_fences",
                column: "route_stop_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_route_stops_route_id",
                table: "route_stops",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_route_timings_route_id",
                table: "route_timings",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_route_timings_vehicle_id",
                table: "route_timings",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_routegeofencecords_route_id",
                table: "routegeofencecords",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_routes_organization_id",
                table: "routes",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_routes_vehicle_id",
                table: "routes",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_sms_notification_user_id",
                table: "sms_notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_static_medias_key",
                table: "static_medias",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tracker_device_alarms_tracker_device_id",
                table: "tracker_device_alarms",
                column: "tracker_device_id");

            migrationBuilder.CreateIndex(
                name: "ix_tracker_devices_org_id",
                table: "tracker_devices",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "ix_trackerlocations_tracker_device_id",
                table: "trackerlocations",
                column: "tracker_device_id");

            migrationBuilder.CreateIndex(
                name: "ix_trip_active_geo_fences_stop_geofence_id",
                table: "trip_active_geo_fences",
                column: "stop_geofence_id");

            migrationBuilder.CreateIndex(
                name: "ix_trip_active_geo_fences_trip_id",
                table: "trip_active_geo_fences",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_trip_locations_trip_id",
                table: "trip_locations",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_trip_notifications_trip_id",
                table: "trip_notifications",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_trip_notifications_user_id",
                table: "trip_notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_trip_subscribers_subscriber_id",
                table: "trip_subscribers",
                column: "subscriber_id");

            migrationBuilder.CreateIndex(
                name: "ix_trips_driver_id",
                table: "trips",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "ix_trips_route_id",
                table: "trips",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_trips_tracker_device_id",
                table: "trips",
                column: "tracker_device_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_device_infoes_user_id",
                table: "user_device_infoes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_ot_ps_user_id",
                table: "user_ot_ps",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_base_user_id",
                table: "users",
                column: "base_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_organization_id",
                table: "users",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_profile_id",
                table: "users",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_route_id",
                table: "users",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_usertemppass_base_user_id",
                table: "usertemppass",
                column: "base_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_usertemppass_created_by_id",
                table: "usertemppass",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_alert_users_alert_id",
                table: "vehicle_alert_users",
                column: "alert_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_alert_users_user_id",
                table: "vehicle_alert_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_alerts_tracker_device_alarm_id",
                table: "vehicle_alerts",
                column: "tracker_device_alarm_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_alerts_tracker_device_id",
                table: "vehicle_alerts",
                column: "tracker_device_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_alerts_trip_id",
                table: "vehicle_alerts",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_alerts_vehicle_id",
                table: "vehicle_alerts",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_distance_traveled_trip_id",
                table: "vehicle_distance_traveled",
                column: "trip_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_distance_traveled_vehicle_id",
                table: "vehicle_distance_traveled",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_medias_file_id",
                table: "vehicle_medias",
                column: "file_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_medias_vehicle_id",
                table: "vehicle_medias",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_busdriver_id",
                table: "vehicles",
                column: "busdriver_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_org_id",
                table: "vehicles",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicletdlogs_tracker_device_id",
                table: "vehicletdlogs",
                column: "tracker_device_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicletdlogs_vehicle_id",
                table: "vehicletdlogs",
                column: "vehicle_id");

            migrationBuilder.AddForeignKey(
                name: "fk_email_notifications_users_user_id",
                table: "email_notifications",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_events_routes_route_id",
                table: "events",
                column: "route_id",
                principalTable: "routes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_events_users_user_id",
                table: "events",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_login_users_users_user_id",
                table: "login_users",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_messages_trips_trip_id",
                table: "messages",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_messages_users_created_by_id",
                table: "messages",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_messages_users_created_for_id",
                table: "messages",
                column: "for_user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_messages_users_user_id",
                table: "messages",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_route_stop_geo_fences_route_stops_route_stop_id",
                table: "route_stop_geo_fences",
                column: "route_stop_id",
                principalTable: "route_stops",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_route_stops_routes_route_id",
                table: "route_stops",
                column: "route_id",
                principalTable: "routes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_route_timings_routes_route_id",
                table: "route_timings",
                column: "route_id",
                principalTable: "routes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_route_timings_vehicles_vehicle_id",
                table: "route_timings",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_routegeofencecords_routes_route_id",
                table: "routegeofencecords",
                column: "route_id",
                principalTable: "routes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_routes_vehicles_vehicle_id",
                table: "routes",
                column: "vehicle_id",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_users_busdriver_id",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "email_notifications");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "login_users");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "organization_off_days");

            migrationBuilder.DropTable(
                name: "orgtrackerdevices");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "push_notification");

            migrationBuilder.DropTable(
                name: "route_timings");

            migrationBuilder.DropTable(
                name: "routegeofencecords");

            migrationBuilder.DropTable(
                name: "sms_notification");

            migrationBuilder.DropTable(
                name: "trackerlocations");

            migrationBuilder.DropTable(
                name: "trip_active_geo_fences");

            migrationBuilder.DropTable(
                name: "trip_locations");

            migrationBuilder.DropTable(
                name: "trip_notifications");

            migrationBuilder.DropTable(
                name: "trip_subscribers");

            migrationBuilder.DropTable(
                name: "user_device_infoes");

            migrationBuilder.DropTable(
                name: "user_ot_ps");

            migrationBuilder.DropTable(
                name: "usertemppass");

            migrationBuilder.DropTable(
                name: "vehicle_alert_users");

            migrationBuilder.DropTable(
                name: "vehicle_distance_traveled");

            migrationBuilder.DropTable(
                name: "vehicle_medias");

            migrationBuilder.DropTable(
                name: "vehicletdlogs");

            migrationBuilder.DropTable(
                name: "attachments");

            migrationBuilder.DropTable(
                name: "route_stop_geo_fences");

            migrationBuilder.DropTable(
                name: "vehicle_alerts");

            migrationBuilder.DropTable(
                name: "route_stops");

            migrationBuilder.DropTable(
                name: "tracker_device_alarms");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "tracker_devices");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "base_users");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "static_medias");
        }
    }
}
