FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

COPY ./publish /app

RUN curl -LO https://github.com/DataDog/dd-trace-dotnet/releases/download/v#{Datadog.Agent.InstallPackage.Version}#/datadog-dotnet-apm_#{Datadog.Agent.InstallPackage.Version}#_amd64.deb \
&& dpkg -i ./datadog-dotnet-apm_#{Datadog.Agent.InstallPackage.Version}#_amd64.deb 

ENV ASPNETCORE_ENVIRONMENT=#{Dotnet.Application.Environment.Name}# \
CORECLR_ENABLE_PROFILING=#{Datadog.Agent.CoreclrEnableProfiling.Id}# \
CORECLR_PROFILER=#{Datadog.Agent.CoreclrProfiler.Key}# \
CORECLR_PROFILER_PATH=#{Datadog.Agent.CoreclrProfiler.Path}# \
DD_DOTNET_TRACER_HOME=#{Datadog.Agent.DotnetTracerHome.Path}# \
DD_ENV=#{Datadog.Agent.Environment.Name}# \
DD_INTEGRATIONS=#{Datadog.Agent.Integrations.Path}# \
DD_LOGS_INJECTION=#{Datadog.Agent.LogsInjection.Enabled}# \
DD_SERVICE=#{Datadog.Agent.Application.Name}# \
DD_TRACE_ANALYTICS_ENABLED=#{Datadog.Agent.TraceAnalytics.Enabled}# \
DD_TRACE_DEBUG=#{Datadog.Agent.TraceDebug.Enabled}# \
DD_TRACE_ENABLED=#{Datadog.Agent.Trace.Enabled}# \
DD_VERSION=#{Datadog.Agent.Application.Version}# \
TAG_APPLICATION_BUILD_VERSION="#{Tag.Application.Build.Version}#"

ENTRYPOINT ["dotnet", "#{Dotnet.Application.Binary.Name}#"]
