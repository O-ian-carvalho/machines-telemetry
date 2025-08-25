export interface Telemetry {
  id: string;
  latitude: number;
  longitude: number;
  status: string;
}

export interface TelemetryPost {
  latitude: number;
  longitude: number;
  status: string;
}