export interface Account {
    username: string;
    password: string;
    email?: string;
    roleId?: number;
    status?: string;
    firstName?: string;
    lastName?: string;
    dateOfBirth?: Date;
    gender?: string;
    address?: string;
    phoneNumber?: string;
    languagePreference?: string;
    avatar?: string;
}
