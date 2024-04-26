<template>
  <v-container fluid>
    <SlideShow />
    <!-- dùng v-tab để làm các tab trong 1 trang -->
    <!-- <v-card>
      <v-tabs align-tabs="center">
        <v-tab v-for="(item, index) in movieTab" :key="index">
          {{ item.name }}
        </v-tab>
      </v-tabs>
    </v-card> -->
  </v-container>
</template>

<script>
import SlideShow from "@/components/Slideshow.vue";
export default {
  name: "HomePage",
  components: {
    SlideShow,
  },
  data() {
    return {
      movieTab: [
        { name: "PHIM SẮP CHIẾU", listMovie: [] },
        { name: "PHIM ĐANG CHIẾU", listMovie: [] },
        { name: "SUẤT CHIẾU ĐẶC BIỆT", listMovie: [] },
      ],
    };
  },
};
</script>
