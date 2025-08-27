export interface Telemetry {
  id: string;
  createdAt: Date,
  latitude: number;
  longitude: number;
  status: string;
}

export interface TelemetryPost {
  latitude: number;
  longitude: number;
  status: string;
}