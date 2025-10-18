export interface MessageModel{
    id?: string;
    chatRoomId: string;
    senderId: string;
    recipientId: string;
    content: string;
    createdAt?: Date;
}




