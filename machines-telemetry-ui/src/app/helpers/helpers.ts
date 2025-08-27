export class Helpers{
    
  static mapStatus(status: string): string {
    switch (status) {
      case 'Maintenance':
        return 'Em manutenção';
      case 'Operating':
        return 'Em funcionamento';
      case 'Stopped':
        return 'Parado';
      default:
        return 'Indefinido';
    }
  }
}