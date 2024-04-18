<template>
  <v-container fluid>
    <v-carousel cycle interval="4000" hide-delimiter-background>
      <v-carousel-item v-for="(item, index) in carouselItem" :key="index">
        <v-img :src="item.img"></v-img>
      </v-carousel-item>
    </v-carousel>
    <!-- dùng v-tab để làm các tab trong 1 trang -->
    <v-card>
      <v-tabs align-tabs="center">
        <v-tab v-for="(item, index) in movieTab" :key="index">
          {{ item.name }}
        </v-tab>
      </v-tabs>
    </v-card>
  </v-container>
</template>

<script>
export default {
  name: "HomePage",
  data() {
    return {
      carouselItem: [
        {
          img: require("@/assets/SlideShow/huong-dan-dang-nhap.png"),
          link: "https://betacinemas.vn/tin-ben-le/huong-dan-dang-nhap-tai-khoan-beta-cinemas.htm",
        },
        {
          img: require("@/assets/SlideShow/sap-khai-truong.png"),
          link: "https://betacinemas.vn/beta-cinemas-ung-van-khiem-sieu-pham-trong-thoi-gian-toi.htm",
        },
      ],
      movieTab: [
        { name: "PHIM SẮP CHIẾU", listMovie: [] },
        { name: "PHIM ĐANG CHIẾU", listMovie: [] },
        { name: "SUẤT CHIẾU ĐẶC BIỆT", listMovie: [] },
      ],
    };
  },
};
</script>
