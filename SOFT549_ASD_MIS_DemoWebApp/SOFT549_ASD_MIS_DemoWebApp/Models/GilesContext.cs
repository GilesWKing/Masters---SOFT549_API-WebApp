using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//API Namespace Requirements
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class GilesContext : DbContext
    {
        #region Variables

        private HttpClient _httpClient;
        private Uri _apiBaseURL;

        #endregion

        #region Constructors

        public GilesContext()
        {
        }

        public GilesContext(DbContextOptions<GilesContext> options)
            : base(options)
        {
            _httpClient = new HttpClient();
            _apiBaseURL = new Uri("https://localhost:44318/api/");
        }

        #endregion

        #region Database Methods

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Initial Catalog=Giles;User ID=Giles;Password=10147671;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasColumnName("activity_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivitySequence).HasColumnName("activity_sequence");

                entity.Property(e => e.ActualCompletionDate)
                    .HasColumnName("actual_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.ActualCost).HasColumnName("actual_cost");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnName("actual_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCompletionDate)
                    .HasColumnName("predicted_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCost).HasColumnName("predicted_cost");

                entity.Property(e => e.PredictedStartDate)
                    .HasColumnName("predicted_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Project");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Staff");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.ActualCompletionDate)
                    .HasColumnName("actual_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.ActualCost).HasColumnName("actual_cost");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnName("actual_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCompletionDate)
                    .HasColumnName("predicted_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCost).HasColumnName("predicted_cost");

                entity.Property(e => e.PredictedStartDate)
                    .HasColumnName("predicted_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("task_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskSequence).HasColumnName("task_sequence");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Activity");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment_Staff");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientContact)
                    .IsRequired()
                    .HasColumnName("client_contact")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("client_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ActualCompletionDate)
                    .HasColumnName("actual_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.ActualCost)
                    .HasColumnName("actual_cost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActualLaunchDate)
                    .HasColumnName("actual_launch_date")
                    .HasColumnType("date");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.PredictedCompletionDate)
                    .HasColumnName("predicted_completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.PredictedCost)
                    .IsRequired()
                    .HasColumnName("predicted_cost")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PredictedLaunchDate)
                    .HasColumnName("predicted_launch_date")
                    .HasColumnType("date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("project_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Client");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.CostPerHour).HasColumnName("cost_per_hour");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ContactDetails)
                    .HasColumnName("contact_details")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Organisation)
                    .IsRequired()
                    .HasColumnName("organisation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasColumnName("staff_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Staff_Client");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Role");
            });
        }

        #endregion

        #region API Methods

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(_apiBaseURL, relativePath);
            var uriBuilder = new UriBuilder(endpoint);

            uriBuilder.Query = queryString;

            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void AddHeaders()
        {
            //_httpClient.DefaultRequestHeaders.Remove("apiKey");
            //_httpClient.DefaultRequestHeaders.Add("apiKey", "gskfjnDHsdf8dfnh:LZASFDs8dfhp;szdf089ufp;klnfd");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
        
        private Uri StartAPICall(string apiCommand)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, apiCommand));

            AddHeaders();

            return requestUrl;
        }

        public async Task<T> GetAPICall<T>(string apiCommand)
        {
            Uri requestUrl = StartAPICall(apiCommand);

            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> PostAPICall<T>(string apiCommand, T data)
        {
            Uri requestUrl = StartAPICall(apiCommand);

            var response = await _httpClient.PostAsync(requestUrl, CreateHttpContent<T>(data));
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> PutAPICall<T>(string apiCommand, T data)
        {
            Uri requestUrl = StartAPICall(apiCommand);

            var response = await _httpClient.PutAsync(requestUrl, CreateHttpContent<T>(data));
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> DeleteAPICall<T>(string apiCommand)
        {
            Uri requestUrl = StartAPICall(apiCommand);

            var response = await _httpClient.DeleteAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        #endregion
    }
}
